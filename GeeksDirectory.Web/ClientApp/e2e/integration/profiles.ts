import { CONFIG } from '../support/config';
import { IProfile } from '../responses';

describe('Profiles', () => {
    beforeEach(() => {
        cy.login(CONFIG.email, CONFIG.password);
        cy.visit('/profiles');
    });

    it('open profile', () => {
        cy.server();
        cy.route({
            method: 'GET',
            url: 'api/profiles?*'
        }).as('profileRequest');

        cy.get('[data-cy=profileCard][id=3]')
            .find('[data-cy=openProfile]')
            .click();
        cy.go('back');

        cy.get('[data-cy=profileCard][id=1]')
            .find('[data-cy=openProfile]')
            .click();
        cy.go('back');

        cy.get('.mat-drawer-content').scrollTo('bottom');
        cy.wait('@profileRequest');

        cy.get('.mat-drawer-content').scrollTo('bottom');
        cy.wait('@profileRequest');
    });

    it('edit personal profile with success', () => {
        cy.server();
        cy.route({ method: 'PATCH', url: 'api/profiles/me' }).as('updateProfile');

        let profile = JSON.parse(sessionStorage.getItem('gd-profile') || '') as IProfile;
        cy.get(`[data-cy=profileCard][id=${profile.id}]`)
            .find('[data-cy=openProfile]')
            .click();
        cy.get('[data-cy=update]')
            .children()
            .click();

        cy.wait('@updateProfile');
        cy.contains('Personal profile has been updated.');
    });

    it('edit profile is not available', () => {
        let profile = JSON.parse(sessionStorage.getItem('gd-profile') || '') as IProfile;

        cy.get(`[data-cy=profileCard][id=${profile.id + 1}]`)
            .find('[data-cy=openProfile]')
            .click();

        cy.get('[data-cy=update]')
            .contains('Update')
            .should('not.exist');

        cy.go('back');

        cy.get(`[data-cy=profileCard][id=${profile.id + 2}]`)
            .find('[data-cy=openProfile]')
            .click();

        cy.get('[data-cy=update]')
            .contains('Update')
            .should('not.exist');
    });

    it('edit profile invalid model', () => {
        let profile = JSON.parse(sessionStorage.getItem('gd-profile') || '') as IProfile;
        cy.get('[data-cy=welcomeMessage]').click();

        cy.url().should('contain', `/profiles/${profile.id}`);

        cy.get('[data-cy=name]').clear();
        cy.get('[data-cy=surname]').focus();
        cy.contains('Name is required');

        cy.get('[data-cy=surname]').clear();
        cy.get('[data-cy=middleName]').focus();
        cy.contains('Surname is required');

        cy.get('[data-cy=city]')
            .clear()
            .type('{esc}')
            .should('have.class', 'ng-invalid');

        cy.get('[data-cy=submit]').should('have.attr', 'disabled');
    });
});
