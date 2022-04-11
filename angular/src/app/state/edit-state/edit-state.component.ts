import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '../../../shared/app-component-base';
import { CountryServiceProxy, CreateOrEditStateDto, GetCountryForViewDto, GetCountryForViewDtoPagedResultDto, GetStateForEditOutput, GetStateForViewDto, GetStateForViewDtoPagedResultDto, StateDto, StateServiceProxy } from '../../../shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-state',
  templateUrl: './edit-state.component.html'
  
})
export class EditStateComponent extends AppComponentBase implements OnInit {

    saving = false;
    id: number;
    states = new CreateOrEditStateDto();
    countriesStates: GetCountryForViewDto[] = [];
    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        private _router: Router,
        private _stateServiceProxy: StateServiceProxy,
        private _countryServiceProxy: CountryServiceProxy,
        public bsModalRef: BsModalRef
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._stateServiceProxy
            .getStateForEdit(this.id)
            .subscribe((result: GetStateForEditOutput) => {
                this.states = result.state;

            });

        this._countryServiceProxy
            .getAllCountry('', '', '', undefined, undefined)
            .pipe(
                finalize(() => {

                })
            )
            .subscribe((result: GetCountryForViewDtoPagedResultDto) => {
                this.countriesStates = result.items;

            });
    }


    save(): void {
        this.saving = true;
        const state = new StateDto();
        state.init(this.states);


        this._stateServiceProxy.createOrEdit(state).subscribe(
            () => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.bsModalRef.hide();
                this.onSave.emit();
                this._router.navigate(['/app/state'])
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
