import { Directive } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
	selector: '[gdNoWhiteSpace]',
	providers: [{ provide: NG_VALIDATORS, useExisting: NoWhiteSpaceDirective, multi: true }]
})
export class NoWhiteSpaceDirective implements Validator {
	validate(control: AbstractControl): ValidationErrors {
		return control.value && (control.value as string).indexOf(' ') >= 0 ? { noWhiteSpace: true } : null;
	}
}
