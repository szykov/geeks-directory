import { Directive } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
	selector: '[gdHasLowerCase]',
	providers: [{ provide: NG_VALIDATORS, useExisting: HasLowerCaseDirective, multi: true }]
})
export class HasLowerCaseDirective implements Validator {
	validate(control: AbstractControl): ValidationErrors {
		return control.value && /[a-z]/.test(control.value) ? null : { hasLowerCase: true };
	}
}
