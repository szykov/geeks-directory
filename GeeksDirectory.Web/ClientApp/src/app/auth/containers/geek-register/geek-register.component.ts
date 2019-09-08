import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromAuth from '@app/auth/reducers';

import { CreateProfileModel } from '../../../models';
import { CITIES } from '@shared/common';
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

    constructor(private store: Store<fromAuth.State>) {}

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
        this.store.dispatch(RegistrationActions.registerProfile({ profile: this.model }));
    }

    public onChangeCity(value: string) {
        this.cityValue$.next(value);
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}
