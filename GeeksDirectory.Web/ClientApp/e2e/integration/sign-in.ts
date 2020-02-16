import { CONFIG } from '../support/config';

describe('Sign In', () => {
    beforeEach(() => {
        cy.server();
        cy.route('api/profiles?*').as('profilesApi');

        cy.visit('/profiles');
        cy.wait('@profilesApi');

        cy.get('[data-cy=signIn]').click();
        cy.get('mat-dialog-container');
    });

    it('sign in with success', () => {
        cy.get('[data-cy=email]').type(CONFIG.email);
        cy.get('[data-cy=password]').type(CONFIG.password);
        cy.get('[data-cy=submit]').click();

        cy.route('api/profiles/me').as('personalProfile');
        cy.wait('@personalProfile');

        cy.url().should('include', '/profiles/');
        cy.url().should('not.include', 'signIn=true');

        cy.contains('You have sucessfully signed in.');
        cy.get('[data-cy=title]').contains('Sergey Zykov');

        cy.get('[data-cy=topMenu]').click();
        cy.get('[data-cy=signOut]').click();

        cy.contains('You have sucessfully signed out.');
    });

    it('sign in with wrong password', () => {
        cy.get('[data-cy=email]').type(CONFIG.email);
        cy.get('[data-cy=password]').type('wrong password');
        cy.get('[data-cy=submit]').click();

        cy.contains('The username/password couple is invalid.');
        cy.get('mat-dialog-container');

        cy.get('[data-cy=email]').should('have.value', CONFIG.email);
        cy.get('[data-cy=password]').should('have.value', 'wrong password');
    });

    it('try sign in with invalid email', () => {
        cy.get('[data-cy=email]').type('wrong email');
        cy.get('[data-cy=password]').click();

        cy.contains('Email is invalid');
        cy.get('[data-cy=submit]').should('have.attr', 'disabled');
    });

    it('route to create account page', () => {
        cy.get('[data-cy=createAccount]').click();

        cy.url().should('not.include', 'signIn=true');
        cy.url().should('include', 'registration');
        cy.get('[data-cy=title]').contains('Profile registration');
    });

    it('cancel sign in', () => {
        cy.get('[data-cy=cancel]').click();
        cy.get('mat-dialog-container').should('not.exist');
        cy.url().should('not.include', 'signIn=true');
    });
});
