import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { mergeMap, map, tap, exhaustMap, catchError } from 'rxjs/operators';

import { RequestService, NotificationService } from '@app/services';
import { DialogService } from '@app/services';
import { ProfilesDetailsActions, SkillsApiActions, SkillsDialog } from '../actions';
import { DialogChoice } from '@shared/common';
import { of } from 'rxjs';

@Injectable()
export class SkillsEffects {
    constructor(
        private requestService: RequestService,
        private dialogService: DialogService,
        private notificationService: NotificationService,
        private actions$: Actions
    ) {}

    openAddSkillDialog$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesDetailsActions.openAddSkillDialog),
            exhaustMap(({ profileId }) => this.dialogService.addSkillDialog(profileId)),
            map(({ choice, profileId, model }) => {
                switch (choice) {
                    case DialogChoice.Ok:
                        return SkillsDialog.addSkillOk({ profileId, model });

                    default:
                        return SkillsDialog.addSkillCanceled();
                }
            })
        )
    );

    addSkill$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SkillsDialog.addSkillOk),
            mergeMap(({ profileId, model }) =>
                this.requestService.addSkill(profileId, model).pipe(
                    tap(() => this.notificationService.showSuccess('Skill has been added.')),
                    map(
                        result => SkillsApiActions.addSkillSuccess({ skill: result }),
                        catchError(() => of(ProfilesDetailsActions.openAddSkillDialog({ profileId, model })))
                    )
                )
            )
        )
    );

    editAddSkillDialog$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesDetailsActions.openEditSkillDialog),
            exhaustMap(({ profileId, model }) => this.dialogService.editSkillDialog(profileId, { ...model })),
            map(({ choice, profileId, model }) => {
                switch (choice) {
                    case DialogChoice.Ok:
                        return SkillsDialog.editSkillOk({ profileId, model });

                    default:
                        return SkillsDialog.editSkillCanceled();
                }
            })
        )
    );

    editSkill$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SkillsDialog.editSkillOk),
            mergeMap(({ profileId, model }) =>
                this.requestService.setSkillScore(profileId, model.name, { score: model.score }).pipe(
                    tap(() => this.notificationService.showSuccess('Skill has been evaluated.')),
                    map(
                        result => SkillsApiActions.evaluateSkillSuccess({ skill: result }),
                        catchError(() => of(ProfilesDetailsActions.openAddSkillDialog({ profileId, model })))
                    )
                )
            )
        )
    );
}
