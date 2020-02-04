import { IProfilesEnvelope } from '../responses';

describe('Search', () => {
    beforeEach(() => {
        cy.server();
        cy.route('api/profiles/search*').as('searchApi');
        cy.route('api/profiles*').as('profilesApi');

        cy.visit('/profiles/search');
        cy.wait('@profilesApi');
    });

    it.only('enter profile', () => {
        cy.get('[data-cy=searchTable] tbody tr:nth-child(1)').click();
        cy.url().should('include', 'profiles/1');

        cy.go('back');

        cy.get('[data-cy=searchTable] tbody tr:nth-child(3)').click();
        cy.url().should('include', 'profiles/3');
    });

    it('change limit', () => {
        cy.get('[data-cy=searchTable]')
            .find('tbody tr')
            .should('have.length', 10);

        cy.get('#mat-select-0').click();
        cy.get('#mat-option-1').click();

        cy.get('[data-cy=searchTable]')
            .find('tbody tr')
            .should('have.length', 20);

        cy.wait('@profilesApi')
            .its('url')
            .should('include', 'limit=20');

        cy.get('#mat-select-0').click();
        cy.get('#mat-option-2').click();

        cy.get('[data-cy=searchTable]')
            .find('tbody tr')
            .should('have.length.greaterThan', 20);
    });

    it('change offset', () => {
        cy.get('.mat-paginator button:nth-child(2)').as('start');
        cy.get('.mat-paginator button:nth-child(3)').as('back');
        cy.get('.mat-paginator button:nth-child(4)').as('next');
        cy.get('.mat-paginator button:nth-child(5)').as('end');

        cy.get('@next').click();
        cy.wait('@profilesApi').then(xhr => {
            let response = xhr.response.body as IProfilesEnvelope;
            expect(response.data).to.have.length(10);
            expect(response.data[0].id).to.equal(11);
            expect(xhr.url).to.include('offset=10');
        });

        cy.get('@back').click();
        cy.wait('@profilesApi').then(xhr => {
            let response = xhr.response.body as IProfilesEnvelope;
            expect(response.data).to.have.length(10);
            expect(response.data[0].id).to.equal(1);
            expect(xhr.url).to.include('offset=0');
        });

        cy.get('@end').click();
        cy.wait('@profilesApi').then(xhr => {
            let response = xhr.response.body as IProfilesEnvelope;
            let count = response.data.length % response.pagination.total;
            expect(response.data).to.have.length(count);
            expect(response.data[0].id).to.equal(response.pagination.total - count + 1);
            expect(xhr.url).to.include(`offset=${response.pagination.total - count}`);
        });

        cy.get('@start').click();
        cy.wait('@profilesApi').then(xhr => {
            let response = xhr.response.body as IProfilesEnvelope;
            expect(response.data).to.have.length(10);
            expect(response.data[0].id).to.equal(1);
            expect(xhr.url).to.include('offset=0');
        });
    });

    it('sorty by id', () => {
        cy.sort('id', (a: any, b: any) => a - b);
        cy.reverse('id', (a: any, b: any) => a - b);
    });

    it('sorty by email', () => {
        cy.sort('email');
        cy.reverse('email');
    });

    it('sorty by name', () => {
        cy.sort('name');
        cy.reverse('name');
    });

    it('sorty by surname', () => {
        cy.sort('surname');
        cy.reverse('surname');
    });

    it('sorty by city', () => {
        cy.sort('city');
        cy.reverse('city');
    });

    it('search by email', () => {
        cy.search('sergey', 'email');
    });

    it('search by name', () => {
        cy.search('Sergey', 'name');
    });

    it('search by surname', () => {
        cy.search('Zykov', 'surname');
    });

    it('search by city', () => {
        cy.search('Moscow', 'city');
    });
});
