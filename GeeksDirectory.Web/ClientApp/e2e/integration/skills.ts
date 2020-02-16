import { CONFIG } from '../support/config';

describe('Skills', () => {
    beforeEach(() => {
        cy.login(CONFIG.email, CONFIG.password);
        cy.visit('/profiles');
    });

    it('add skill', () => {
        cy.server();
        cy.fixture('add_skill_ok').as('skillResponse');
        cy.route({ method: 'POST', url: 'api/profiles/3/skills', response: '@skillResponse' });

        cy.get('[data-cy=profileCard][id=3]')
            .find('[data-cy=openProfile]')
            .click();

        cy.get('[data-cy=addSkill]').click();
        cy.contains('New skill');

        cy.get('[data-cy=skillName]').type('js');
        cy.get('[data-cy=skillDescription]').type('the same as java');
        cy.get('[data-cy=score]')
            .children()
            .eq(5)
            .click();
        cy.get('[data-cy=skillOk]').click();

        cy.contains('Skill has been added.');
        cy.get('[data-cy=skill]')
            .last()
            .children()
            .should('contain.text', 'js');
    });

    it('skill name is invalid', () => {
        cy.get('[data-cy=profileCard][id=3]')
            .find('[data-cy=openProfile]')
            .click();

        cy.get('[data-cy=addSkill]').click();
        cy.get('[data-cy=skillName]').type('^_ _^');
        cy.get('[data-cy=skillDescription]').focus();

        cy.contains('Name should not have white spaces');
        cy.contains('Name should not have special letters');
        cy.get('[data-cy=skillOk]').should('have.attr', 'disabled');

        cy.get('[data-cy=skillName]').clear();
        cy.contains('Name is required');
        cy.get('[data-cy=skillOk]').should('have.attr', 'disabled');
    });

    it('evaluate skill', () => {
        cy.get('[data-cy=profileCard][id=1]')
            .find('[data-cy=openProfile]')
            .click();

        cy.get('[data-cy=skill]')
            .first()
            .as('selectedSkill')
            .click();

        cy.get('[data-cy=score]')
            .children()
            .eq(3)
            .as('selectedScore')
            .click();

        cy.get('[data-cy=skillOk]').click();
        cy.contains('Skill has been evaluated.');

        cy.get('@selectedSkill').click();
        cy.get('@selectedScore').should('have.class', 'checked');
    });
});
