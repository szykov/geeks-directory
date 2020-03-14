import { Injectable } from '@angular/core';

import { of } from 'rxjs';
import { mergeMap, map, tap, exhaustMap, catchError, concatMap } from 'rxjs/operators';

import { Actions, ofType, createEffect } from '@ngrx/effects';

import { RequestService, NotificationService } from '@app/services';
import { DialogService } from '@app/services';
import { ProfilesDetailsActions, SkillsApiActions, SkillsDialog } from '@app/directory/actions';
import { DialogChoice } from '@shared/common';

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
            map(({ choice, profileId, skillModel }) => {
                switch (choice) {
                    case DialogChoice.Ok:
                        return SkillsDialog.addSkillOk({ profileId, skillModel });

                    default:
                        return SkillsDialog.addSkillCanceled();
                }
            })
        )
    );

    addSkill$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SkillsDialog.addSkillOk),
            mergeMap(({ profileId, skillModel }) =>
                this.requestService.addSkill(profileId, skillModel).pipe(
                    tap(() => this.notificationService.showSuccess('Skill has been added.')),
                    map(
                        result => SkillsApiActions.addSkillSuccess({ skill: result }),
                        catchError(() => of(ProfilesDetailsActions.openAddSkillDialog({ profileId })))
                    )
                )
            )
        )
    );

    evaluateSkillDialog$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesDetailsActions.evaluateSkillDialog),
            concatMap(({ profileId, skillId, skillModel }) =>
                this.requestService
                    .getMySkillEvaluation(profileId, skillId)
                    .pipe(map(assessment => ({ profileId, skillId, skillModel, assessment })))
            ),
            exhaustMap(({ profileId, skillId, skillModel, assessment }) => {
                let model = { ...skillModel };
                model.score = assessment ? assessment.score : null;
                return this.dialogService.evaluateSkillDialog(profileId, skillId, { ...model });
            }),
            map(({ choice, profileId, skillId, skillModel }) => {
                switch (choice) {
                    case DialogChoice.Ok:
                        return SkillsDialog.evaluateSkillOk({ profileId, skillId, skillModel });

                    default:
                        return SkillsDialog.evaluateSkillCanceled();
                }
            })
        )
    );

    evaluateSkill$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SkillsDialog.evaluateSkillOk),
            mergeMap(({ profileId, skillId, skillModel }) =>
                this.requestService.setSkillScore(profileId, skillId, { score: skillModel.score }).pipe(
                    tap(() => this.notificationService.showSuccess('Skill has been evaluated.')),
                    map(
                        skill => SkillsApiActions.evaluateSkillSuccess({ skill }),
                        catchError(() => of(ProfilesDetailsActions.evaluateSkillDialog({ profileId, skillId, skillModel })))
                    )
                )
            )
        )
    );
}
