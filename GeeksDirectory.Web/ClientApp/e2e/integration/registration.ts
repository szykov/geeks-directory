import { CONFIG } from '../support/config';

describe('Registration', () => {
    beforeEach(() => {
        cy.server();

        cy.visit('/registration');
    });

    it('register with success', () => {
        cy.fixture('registration_ok').as('successResult');
        cy.route({ method: 'POST', url: 'api/profiles', response: '@successResult' });

        cy.get('[data-cy=name]').type('Sergey');
        cy.get('[data-cy=surname]').type('Zykov');

        cy.get('[data-cy=city]').type('Moscow');
        cy.get('.mat-autocomplete-panel')
            .children()
            .first()
            .click();

        cy.get('[data-cy=email]').type(CONFIG.email);
        cy.get('[data-cy=password]').type(CONFIG.password);

        cy.get('[data-cy=submit]').click();

        cy.url().should('contain', 'profiles/');
        cy.get('[data-cy=title]').contains('Sergey Zykov');
        cy.get('[data-cy=welcomeMessage]').contains('Sergey Zykov');
    });

    it('profile exists', () => {
        cy.get('[data-cy=name]').type('Sergey');
        cy.get('[data-cy=surname]').type('Zykov');
        cy.get('[data-cy=city]').type('Moscow');

        cy.get('[data-cy=email]').type(CONFIG.email);
        cy.get('[data-cy=password]').type(CONFIG.password);

        cy.get('[data-cy=submit]').click();

        cy.contains('Profile already exists.');
    });

    it('name is required', () => {
        cy.get('[data-cy=name]')
            .type('Sergey')
            .clear()
            .should('have.class', 'ng-invalid');

        cy.get('[data-cy=title]').click();
        cy.contains('Name is required');
    });

    it('surname is required', () => {
        cy.get('[data-cy=surname]')
            .type('Zykov')
            .clear()
            .should('have.class', 'ng-invalid');

        cy.get('[data-cy=title]').click();
        cy.contains('Surname is required');
    });

    it('city is required', () => {
        cy.get('[data-cy=city]')
            .type('Moscow')
            .clear()
            .type('{esc}')
            .should('have.class', 'ng-invalid');

        cy.get('[data-cy=title]').click();
    });

    it('email is required', () => {
        cy.get('[data-cy=email]')
            .type(CONFIG.email)
            .clear()
            .should('have.class', 'ng-invalid');

        cy.get('[data-cy=title]').click();
        cy.contains('Email is required');
    });

    it('password is invalid', () => {
        cy.get('[data-cy=password]').as('password');

        cy.get('@password')
            .type(CONFIG.password)
            .clear()
            .should('have.class', 'ng-invalid');

        cy.get('[data-cy=title]').click();
        cy.contains('Password is required');

        cy.get('@password').type('P');
        cy.contains('Password should have upper case letters').should('not.exist');

        cy.get('@password').type('a');
        cy.contains('Password should have lower case letters').should('not.exist');

        cy.get('@password').type('$$');
        cy.contains('Password should have special letters').should('not.exist');

        cy.get('@password').type('w0');
        cy.contains('Password should have numbers').should('not.exist');

        cy.get('@password').type('rd');
        cy.contains('Password must be of minimum 8 characters length').should('not.exist');

        cy.get('[data-cy=submit]').should('have.attr', 'disabled');
    });
});
