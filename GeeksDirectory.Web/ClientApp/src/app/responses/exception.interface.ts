import { IExceptionDetail } from './exception-detail.interface';

export interface IException {
    code: string;
    message: string;
    details: IExceptionDetail[];
}
