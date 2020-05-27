import { trigger, state, style, transition, animate } from '@angular/animations';

export const onSideNavChange = trigger('onSideNavChange', [
	state(
		'close',
		style({
			'max-width': '60px'
		})
	),
	state(
		'open',
		style({
			'max-width': '230px',
			'min-width': '180px'
		})
	),
	transition('close => open', [animate('250ms ease-in')]),
	transition('open => close', animate('250ms ease-in'))
]);
