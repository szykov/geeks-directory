import { IProfilesEnvelope, IProfile } from '../responses';

// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add("login", (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add("drag", { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add("dismiss", { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite("visit", (originalFn, url, options) => { ... })

// see more example of adding custom commands to Cypress TS interface
// in https://github.com/cypress-io/add-cypress-custom-command-in-typescript
// add new command to the existing Cypress interface
// tslint:disable-next-line no-namespace

Cypress.Commands.add('sort', (name: string, compareFn?: (a: any, b: any) => number) => {
    cy.get(`[data-cy=${name}]`).click();
    cy.wait('@profilesApi').then(xhr => {
        let response = xhr.response.body as IProfilesEnvelope;

        let values = response.data.map(p => (p as any)[name]);
        expect(values.join()).to.equal(values.sort(compareFn).join());
        expect(xhr.url).to.include('orderDirection=asc');
    });
});

Cypress.Commands.add('reverse', (name: string, compareFn?: (a: any, b: any) => number) => {
    cy.get(`[data-cy=${name}]`).click();
    cy.wait('@profilesApi').then(xhr => {
        let response = xhr.response.body as IProfilesEnvelope;
        let values = response.data.map(p => (p as any)[name]);
        expect(values.join()).to.equal(
            values
                .sort(compareFn)
                .reverse()
                .join()
        );
        expect(xhr.url).to.include('orderDirection=desc');
    });
});

Cypress.Commands.add('search', (query: string, fieldName: string) => {
    cy.get('[data-cy=search').type(query);

    cy.url().should('include', `query=${query}`);
    cy.wait('@searchApi').then(xhr => {
        let response = xhr.response.body as IProfilesEnvelope;
        let count = response.data.filter((p: any) => p[fieldName].includes(query)).length;
        expect(response.data.length).to.greaterThan(0);
        expect(response.data.length).to.equal(count);
        expect(xhr.url).to.include(`query=${query}`);
    });
});

// tslint:disable-next-line: no-namespace
declare global {
    namespace Cypress {
        interface Chainable<Subject = any> {
            sort(name: string, compareFn?: (a: any, b: any) => number): Chainable<void>;
            reverse(name: string, compareFn?: (a: any, b: any) => number): Chainable<void>;
            search(query: string, fieldName: string): Chainable<void>;
        }
    }
}
