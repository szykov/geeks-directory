import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { Subject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromAuth from '@app/auth/reducers';

import { CreateProfileModel } from '../../../models';
import { CITIES } from '@shared/common';
import { RequestService, NotificationService } from '../../../services';
import { AuthService } from '@app/auth/services/auth.service';
import { RegistrationActions } from '@app/auth/actions';

@Component({
    selector: 'gd-geek-register',
    templateUrl: './geek-register.component.html',
    styleUrls: ['./geek-register.component.scss']
})
export class GeekRegisterComponent implements OnInit, OnDestroy {
    public hide = true;
    public model: CreateProfileModel = new CreateProfileModel();
    public cities = CITIES;

    private unsubscribe: Subject<void> = new Subject();
    private cityValue$: Subject<string> = new Subject();

    constructor(
        private store: Store<fromAuth.State>,
        private authService: AuthService,
        private requestService: RequestService,
        private notificationService: NotificationService,
        private router: Router
    ) {}

    ngOnInit() {
        this.cityValue$
            .pipe(
                takeUntil(this.unsubscribe),
                debounceTime(300)
            )
            .subscribe(() => this.filterCities());
    }

    private filterCities() {
        this.cities = CITIES.filter(option => option.toLowerCase().includes(this.model.city.toLowerCase()));
    }

    public onSubmit() {
        this.authService
            .registerProfile(this.model)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.notificationService.showSuccess('You have been registered. Great!');

                this.store.dispatch(
                    RegistrationActions.login({ credentials: { email: this.model.email, password: this.model.password } })
                );
            });
    }

    public onChangeCity(value: string) {
        this.cityValue$.next(value);
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}
