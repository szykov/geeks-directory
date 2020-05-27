/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable prettier/prettier */
/* eslint-disable @typescript-eslint/no-empty-function */

import { Component, OnInit, ChangeDetectionStrategy, forwardRef, ChangeDetectorRef } from '@angular/core';
import {
	ControlValueAccessor,
	NG_VALUE_ACCESSOR,
	Validator,
	AbstractControl,
	ValidationErrors,
	NG_VALIDATORS
} from '@angular/forms';

import { CITIES } from '@shared/common';

@Component({
	selector: 'gd-city-select',
	templateUrl: './city-select.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush,
	providers: [
		{
			provide: NG_VALUE_ACCESSOR,
			useExisting: forwardRef(() => CitySelectComponent),
			multi: true
		},
		{
			provide: NG_VALIDATORS,
			useExisting: forwardRef(() => CitySelectComponent),
			multi: true
		}
	]
})
export class CitySelectComponent implements ControlValueAccessor, Validator, OnInit {
	public cities: string[] = CITIES;
	public city: string;
	public disabled: boolean;
	public required: boolean;

	public set value(value: string) {
		if (this.disabled) {
			return;
		}

		this.city = value;
		this.onChangeCity(value);
		this.onChange(value);
		this.onTouch();
	}
	public get value(): string {
		return this.city;
	}

	onChange = (value: any): void => {};
	onTouch = (): void => {};

	constructor(private cdr: ChangeDetectorRef) {}

	ngOnInit(): void {}

	public writeValue(value: string): void {
		this.value = value;
	}
	public registerOnChange(fn: any): void {
		this.onChange = fn;
	}
	public registerOnTouched(fn: any): void {
		this.onTouch = fn;
	}
	public setDisabledState?(isDisabled: boolean): void {
		this.disabled = isDisabled;
		this.cdr.detectChanges();
	}

	validate(control: AbstractControl): ValidationErrors {
		if (this.required && !control.value) {
			return { required: { valid: false } };
		}
		return null;
	}

	public onChangeCity(value: string): void {
		this.cities = value ? CITIES.filter((option) => option.toLowerCase().includes(value.toLowerCase())) : CITIES;
	}
}
