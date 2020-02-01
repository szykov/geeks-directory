import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { mergeMap, map, tap, exhaustMap, catchError, concatMap } from 'rxjs/operators';

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
                        catchError(() => of(ProfilesDetailsActions.openAddSkillDialog({ profileId, skillModel })))
                    )
                )
            )
        )
    );

    editAddSkillDialog$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesDetailsActions.openEditSkillDialog),
            concatMap(({ skillModel, profileId }) =>
                this.requestService
                    .getMySkillEvaluation(profileId, skillModel.name)
                    .pipe(map(assessment => ({ skillModel, profileId, assessment })))
            ),
            exhaustMap(({ skillModel, profileId, assessment }) => {
                let model = { ...skillModel };
                model.score = assessment.score;
                return this.dialogService.editSkillDialog(profileId, { ...model });
            }),
            map(({ choice, profileId, skillModel }) => {
                switch (choice) {
                    case DialogChoice.Ok:
                        return SkillsDialog.editSkillOk({ profileId, skillModel });

                    default:
                        return SkillsDialog.editSkillCanceled();
                }
            })
        )
    );

    editSkill$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SkillsDialog.editSkillOk),
            mergeMap(({ profileId, skillModel }) =>
                this.requestService.setSkillScore(profileId, skillModel.name, { score: skillModel.score }).pipe(
                    tap(() => this.notificationService.showSuccess('Skill has been evaluated.')),
                    map(
                        skill => SkillsApiActions.evaluateSkillSuccess({ skill }),
                        catchError(() => of(ProfilesDetailsActions.openAddSkillDialog({ profileId, skillModel })))
                    )
                )
            )
        )
    );
}
