import { Component, Input, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

import { SCORE_TYPES } from '@app/shared/common';

@Component({
    selector: 'gd-skill-score',
    templateUrl: './skill-score.component.html',
    styleUrls: ['./skill-score.component.scss'],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => SkillScoreComponent),
            multi: true
        }
    ]
})
export class SkillScoreComponent implements ControlValueAccessor {
    @Input() isMin: boolean;
    public scoreTypes = SCORE_TYPES;

    public get score() {
        return this.value;
    }

    public set score(value: number) {
        this.value = value;
        this.propagateChange(value);
    }

    private value: number;

    constructor() {}

    public writeValue = (value: number) => (this.score = value);

    public propagateChange = (_: any) => {};

    public registerOnChange = (fn: any) => (this.propagateChange = fn);

    public onChangeScore = (value: number) => (this.score = value);

    public registerOnTouched(fn: any) {}
}
