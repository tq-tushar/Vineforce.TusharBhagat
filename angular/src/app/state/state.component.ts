import { Component, Injector, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '../../shared/app-component-base';
import { GetStateForViewDto, GetStateForViewDtoPagedResultDto, StateDto, StateServiceProxy } from '../../shared/service-proxies/service-proxies';
import { CreateStateComponent } from './create-state/create-state.component';
import { EditStateComponent } from './edit-state/edit-state.component';

@Component({
  selector: 'app-state',
  templateUrl: './state.component.html'
 
})
export class StateComponent extends AppComponentBase implements OnInit {

    states: GetStateForViewDto[] = [];
    advancedFiltersAreShown = false;
    filterText = '';
    countryNameFilter = '';

    constructor(
        injector: Injector,
        private _stateServiceProxy: StateServiceProxy,
        private _modalService: BsModalService

    ) {
        super(injector);
    }
    ngOnInit(): void {
        this.getAll();
    }
    getAll(): void {
        this._stateServiceProxy
            .getAllState('', '', undefined,'', undefined, undefined)
            .pipe(
                finalize(() => {

                })
            )
            .subscribe((result: GetStateForViewDtoPagedResultDto) => {
                this.states = result.items;

            });
    }
    delete(state: StateDto): void {
        abp.message.confirm(
            this.l('StateDeleteWarningMessage', state.stateName), undefined,
            (result: boolean) => {
                if (result) {
                    this._stateServiceProxy
                        .delete(state.id)
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
    createState(): void {
        this.showCreateOrEditStateDialog();
    }
    editState(state: StateDto): void {
        this.showCreateOrEditStateDialog(state.id);
    }
    showCreateOrEditStateDialog(id?: number): void {
        let createOrEditStateDialog: BsModalRef;
        if (!id) {
            createOrEditStateDialog = this._modalService.show(
                CreateStateComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditStateDialog = this._modalService.show(
                EditStateComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: id,
                    },
                }
            );
        }
        createOrEditStateDialog.content.onSave.subscribe(() => { });
    }

}
