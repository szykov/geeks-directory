import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { Subject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';

import { CreateProfileModel } from '../shared/models';
import { CITIES } from '../shared/common';
import { RequestService, NotificationService } from '../shared/services';

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
    private cityFilter$: Subject<string> = new Subject();

    constructor(
        private requestService: RequestService,
        private notificationService: NotificationService,
        private router: Router
    ) {}

    ngOnInit() {
        this.cityFilter$
            .pipe(debounceTime(300))
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(searchTextValue => {
                this.filterCities(searchTextValue);
            });
    }

    private filterCities(value: string) {
        this.cities = CITIES.filter(option => option.toLowerCase().includes(this.model.city.toLowerCase()));
    }
    public onSubmit() {
        this.requestService
            .registerProfile(this.model)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.router.navigate(['/']);
                this.notificationService.showSuccess('You have been registered. Great!');
            });
    }

    public onKeyUpCity(value: string) {
        this.cityFilter$.next(value);
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}
