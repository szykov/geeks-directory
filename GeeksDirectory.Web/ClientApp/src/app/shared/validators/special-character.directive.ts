import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
	selector: '[gdSpecialCharacter]',
	providers: [{ provide: NG_VALIDATORS, useExisting: SpecialCharacterDirective, multi: true }]
})
export class SpecialCharacterDirective implements Validator {
	@Input() gdSpecialCharacter: boolean;

	validate(control: AbstractControl): ValidationErrors {
		let format = /[!#$@%^&*()_+\-=[\]{};':""\\|,.<>/?]/;
		return format.test(control.value) === this.gdSpecialCharacter ? null : { specialCharacter: true };
	}
}
