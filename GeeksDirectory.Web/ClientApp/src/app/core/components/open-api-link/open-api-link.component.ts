import { Component, ChangeDetectionStrategy, Inject, Input } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material';

import { CONFIG } from '@app/shared/common/config';

@Component({
    selector: 'gd-open-api-link',
    templateUrl: './open-api-link.component.html',
    styles: ['button { text-align: left; }', 'mat-icon { padding-left: 5px; }'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class OpenApiLinkComponent {
    @Input() showText: boolean;
    @Input() height = '36px';
    @Input() width = '120px';

    constructor(
        private matIconRegistry: MatIconRegistry,
        private domSanitizer: DomSanitizer,
        @Inject(DOCUMENT) private document: Document
    ) {
        this.matIconRegistry.addSvgIcon(
            'open-api',
            this.domSanitizer.bypassSecurityTrustResourceUrl('/assets/icons/swagger-seeklogo.svg')
        );
    }

    public goToSpecs() {
        this.document.location.href = CONFIG.specsUrl;
    }
}
