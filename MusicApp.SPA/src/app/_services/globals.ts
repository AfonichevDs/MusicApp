import { Observable } from "rxjs/Observable";

export function handleError(error:any) {
    const applicationError = error.headers.get('Application-Error');
    if(applicationError) {
        return Observable.throw(applicationError);
    }

    const serverError = error.json();
    let modelStateErrors = '';
    if(serverError) {
        for (const key in serverError) {
            if(serverError[key]) {
                modelStateErrors += serverError[key] + '\n';
            }
        }
    }
    return Observable.throw(
        modelStateErrors || 'Server Error'
    );
}
