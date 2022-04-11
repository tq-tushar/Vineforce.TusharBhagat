import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import { CountryDto, CountryServiceProxy, CreateOrEditCountryDto, GetCountryForEditOutput } from '../../../shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-country',
  templateUrl: './edit-country.component.html'
  
})
export class EditCountryComponent extends AppComponentBase implements OnInit {

    saving = false;
    id: number;
    country = new CreateOrEditCountryDto();
    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        private _router: Router,
        private _countryService: CountryServiceProxy,
        public bsModalRef: BsModalRef
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._countryService
            .getCountryForEdit(this.id)
            .subscribe((result: GetCountryForEditOutput) => {
                this.country = result.country;

            });
    }

 
    save(): void {
        this.saving = true;
        const country = new CountryDto();
        country.init(this.country);
        

        this._countryService.createOrEdit(country).subscribe(
            () => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.bsModalRef.hide();
                this.onSave.emit();
                this._router.navigate(['/app/country'])
                    .then(() => {
                        window.location.reload();

                    });
            },
            () => {
                this.saving = false;
            }
        );
    }
}
