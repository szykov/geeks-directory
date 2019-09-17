import { Directive } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
    selector: '[gdHasNumber]',
    providers: [{ provide: NG_VALIDATORS, useExisting: HasNumberDirective, multi: true }]
})
export class HasNumberDirective implements Validator {
    constructor() {}

    validate(control: AbstractControl): ValidationErrors {
        return control.value && /[0-9]/.test(control.value) ? null : { hasNumber: true };
    }
}
