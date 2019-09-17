import { Directive } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
    selector: '[gdHasUpperCase]',
    providers: [{ provide: NG_VALIDATORS, useExisting: HasUpperCaseDirective, multi: true }]
})
export class HasUpperCaseDirective implements Validator {
    constructor() {}

    validate(control: AbstractControl): ValidationErrors {
        return control.value && /[A-Z]/.test(control.value) ? null : { hasUpperCase: true };
    }
}
