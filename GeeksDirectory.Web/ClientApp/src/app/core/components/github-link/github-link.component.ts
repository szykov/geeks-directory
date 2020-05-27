import { Component, ChangeDetectionStrategy, Inject, Input } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';

import { CONFIG } from '@shared/config';

@Component({
	selector: 'gd-github-link',
	templateUrl: './github-link.component.html',
	styles: ['button { text-align: left; }', 'mat-icon { padding-left: 5px; }'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class GithubLinkComponent {
	@Input() showText: boolean;
	@Input() height = '36px';
	@Input() width = '120px';

	constructor(
		private matIconRegistry: MatIconRegistry,
		private domSanitizer: DomSanitizer,
		@Inject(DOCUMENT) private document: Document
	) {
		this.matIconRegistry.addSvgIcon(
			'github',
			this.domSanitizer.bypassSecurityTrustResourceUrl('/assets/icons/github-circle-white.svg')
		);
	}

	public goToGithub(): void {
		this.document.location.href = CONFIG.gitHubUrl;
	}
}
