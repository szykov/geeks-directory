import { IExceptionDetail } from '.';

export interface IException {
    code: string;
    message: string;
    details: IExceptionDetail[];
}
