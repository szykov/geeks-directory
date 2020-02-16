// tslint:disable: no-string-literal

import { Injectable } from '@angular/core';

import { tap } from 'rxjs/operators';

import { Actions, ofType, createEffect } from '@ngrx/effects';
import { SidebarActions } from '@app/core/actions';

import { SidebarService } from '@app/services';

@Injectable()
export class CoreEffects {
    constructor(private actions$: Actions, private sidebarService: SidebarService) {}

    toogleSidebarMode$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(SidebarActions.toogleModeSidebar),
                tap(() => {
                    this.sidebarService.toogleMode();
                })
            ),
        { dispatch: false }
    );

    toogleSidebarStatus$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(SidebarActions.toogleStatusSidebar),
                tap(() => {
                    this.sidebarService.toogleStatus();
                })
            ),
        { dispatch: false }
    );
}
