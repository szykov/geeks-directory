// tslint:disable: no-string-literal

import { Injectable } from '@angular/core';

import { tap } from 'rxjs/operators';

import { Actions, ofType, createEffect } from '@ngrx/effects';
import { SidebarActions } from '@app/core/actions';

import { SidebarService } from '@app/services';

@Injectable()
export class CoreEffects {
    constructor(private actions$: Actions, private storageService: SidebarService) {}

    toogleSidebarMode$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(SidebarActions.toogleModeSidebar),
                tap(() => {
                    this.storageService.toogleMode();
                })
            ),
        { dispatch: false }
    );

    toogleSidebarStatus$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(SidebarActions.toogleStatusSidebar),
                tap(() => {
                    this.storageService.toogleStatus();
                })
            ),
        { dispatch: false }
    );
}
