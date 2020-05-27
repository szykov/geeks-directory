import { CredentialsModel } from './credentials.model';
import { DialogChoice } from '@app/shared/common/dialog-choices.enum';

export interface ISignDialogResult {
	choice: DialogChoice;
	data: CredentialsModel;
}
