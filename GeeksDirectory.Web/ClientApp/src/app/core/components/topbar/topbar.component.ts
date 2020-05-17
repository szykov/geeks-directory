import { Component, Output, EventEmitter, Input, ChangeDetectionStrategy } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

@Component({
	selector: 'gd-topbar',
	templateUrl: './topbar.component.html',
	styleUrls: ['./topbar.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class TopbarComponent {
	@Input() title: string;
	@Input() fullName: string;
	@Input() profilePath: string;
	@Input() isAuth = false;

	@Output() signOut = new EventEmitter();
	@Output() drawerToggle = new EventEmitter();

	constructor(private router: Router, private route: ActivatedRoute) {}

	openSignInDialog(): void {
		this.router.navigate([], {
			relativeTo: this.route,
			queryParams: { signIn: true },
			queryParamsHandling: 'merge'
		});
	}
}
