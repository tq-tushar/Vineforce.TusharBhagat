import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

import { AppComponentBase } from '../../shared/app-component-base';
import { CountryDto, CountryServiceProxy, GetCountryForViewDto, GetCountryForViewDtoPagedResultDto } from '../../shared/service-proxies/service-proxies';
import { CreateCountryComponent } from './create-country/create-country.component';
import { EditCountryComponent } from './edit-country/edit-country.component';
@Component({
    selector: 'app-country',
    templateUrl: './country.component.html'
    
})
export class CountryComponent extends AppComponentBase implements OnInit {

    countries: GetCountryForViewDto[] = [];
    advancedFiltersAreShown = false;
    filterText = '';
    countryNameFilter = '';

    constructor(
        injector: Injector,
        private _countryServiceProxy: CountryServiceProxy,
        private _modalService: BsModalService

    ) {
        super(injector);
    }
    ngOnInit(): void {
        this.getAll();
    }
    getAll(): void {
        this._countryServiceProxy
            .getAllCountry(this.filterText, this.countryNameFilter, '', undefined,undefined)
            .pipe(
                finalize(() => {
                   
                })
            )
            .subscribe((result:GetCountryForViewDtoPagedResultDto) => {
                this.countries = result.items;
               
            });
    }
    delete(country: CountryDto): void {
        abp.message.confirm(
            this.l('CountryDeleteWarningMessage', country.countryName),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._countryServiceProxy
                        .delete(country.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                               
                            })
                        )
                        .subscribe(() => { this.getAll(); });
                }
                
            }
            
        );
       
    }
    createCountry(): void {
        this.showCreateOrEditCountryDialog();
    }
    editCountry(country: CountryDto): void {
        this.showCreateOrEditCountryDialog(country.id);
    }
    showCreateOrEditCountryDialog(id?: number): void {
        let createOrEditCountryDialog: BsModalRef;
        if (!id) {
            createOrEditCountryDialog = this._modalService.show(
                CreateCountryComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditCountryDialog = this._modalService.show(
                EditCountryComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: id,
                    },
                }
            );
        }

        createOrEditCountryDialog.content.onSave.subscribe(() => {
            
        });
    }
}
