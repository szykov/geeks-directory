import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

import { CreateProfileModel } from '../shared/models';
import { CITIES } from '../shared/common';
import { RequestService, NotificationService } from '../shared/services';
import { Router } from '@angular/router';

@Component({
    selector: 'gd-geek-register',
    templateUrl: './geek-register.component.html',
    styleUrls: ['./geek-register.component.scss']
})
export class GeekRegisterComponent implements OnInit {
    public hide = true;
    public model: CreateProfileModel = new CreateProfileModel();
    public cities = CITIES;

    private cityFilter$: Subject<string> = new Subject();

    constructor(
        private requestService: RequestService,
        private notificationService: NotificationService,
        private router: Router
    ) {}

    ngOnInit() {
        this.cityFilter$.pipe(debounceTime(300)).subscribe(searchTextValue => {
            this.filterCities(searchTextValue);
        });
    }

    private filterCities(value: string) {
        this.cities = CITIES.filter(option => option.toLowerCase().includes(this.model.city.toLowerCase()));
    }
    public onSubmit() {
        this.requestService.registerProfile(this.model).subscribe(result => {
            this.router.navigate(['/']);
            this.notificationService.showSuccess('You have been registered. Great!');
        });
    }

    public onKeyUpCity(value: string) {
        this.cityFilter$.next(value);
    }
}
