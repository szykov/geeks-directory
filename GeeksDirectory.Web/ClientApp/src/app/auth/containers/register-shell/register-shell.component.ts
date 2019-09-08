import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { Subject, BehaviorSubject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromAuth from '@app/auth/reducers';

import { CreateProfileModel } from '@app/models';
import { CITIES } from '@shared/common';
import { RegistrationActions } from '@app/auth/actions';

@Component({
    selector: 'gd-register-shell',
    templateUrl: './register-shell.component.html',
    styleUrls: ['./register-shell.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterShellComponent implements OnInit {
    public model: CreateProfileModel = new CreateProfileModel();

    private unsubscribe: Subject<void> = new Subject();
    public filteredCities$: BehaviorSubject<string[]> = new BehaviorSubject(CITIES);

    constructor(private store: Store<fromAuth.State>) {}

    ngOnInit() {
        this.filteredCities$.pipe(
            takeUntil(this.unsubscribe),
            debounceTime(300)
        );
    }

    public onChangeCity(value: string) {
        let cities = CITIES.filter(option => option.toLowerCase().includes(value.toLowerCase()));
        this.filteredCities$.next(cities);
    }

    public onRegister(profile: CreateProfileModel) {
        this.store.dispatch(RegistrationActions.registerProfile({ profile }));
    }
}
