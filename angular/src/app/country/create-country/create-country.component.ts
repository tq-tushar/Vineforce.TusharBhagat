import { Component, EventEmitter, Injector, OnInit, Optional, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '../../../shared/app-component-base';
import { CountryDto, CountryServiceProxy, CreateOrEditCountryDto, GetCountryForViewDto, GetCountryForViewDtoPagedResultDto } from '../../../shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-country',
  templateUrl: './create-country.component.html'
 
})
export class CreateCountryComponent extends AppComponentBase implements OnInit {

    saving = false;
    country = new CountryDto();
    countries: GetCountryForViewDto[] = [];
   

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
       
    }
    

    save(): void {
        this.saving = true;

        const country = new CreateOrEditCountryDto();
        country.init(this.country);
      

        this._countryService
            .createOrEdit(country)
            .subscribe(
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
