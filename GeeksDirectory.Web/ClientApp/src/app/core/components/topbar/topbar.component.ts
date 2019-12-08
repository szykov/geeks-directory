import { Component, Output, EventEmitter, Input, ChangeDetectionStrategy, Inject } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { DOCUMENT } from '@angular/common';

import { MatIconRegistry } from '@angular/material';

import { CONFIG } from '@app/shared/common';
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

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private matIconRegistry: MatIconRegistry,
        private domSanitizer: DomSanitizer,
        @Inject(DOCUMENT) private document: Document
    ) {
        this.matIconRegistry.addSvgIcon(
            'github',
            this.domSanitizer.bypassSecurityTrustResourceUrl('/assets/icons/github-circle-white.svg')
        );
    }

    public goToGithub() {
        this.document.location.href = CONFIG.gitHubUrl;
    }

    openSignInDialog() {
        this.router.navigate([], { relativeTo: this.route, queryParams: { signIn: true }, queryParamsHandling: 'merge' });
    }
}
