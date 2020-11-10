import axios from 'axios';
import { PoemInterface } from '@/models/poem.interface';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';


class PoemService extends BaseService {

    private static instance: PoemService;

    private constructor() {  super(); }

    public static get Instance() {
       // Do you need arguments? Make it a regular method instead.
       return this.instance || (this.instance = new this());
    }

    public save(poemInterface: PoemInterface): Observable<any> {
        return Observable.fromPromise(axios.post(`${this.api}/poem`, poemInterface))
        .map((res: any) => true)
        .catch((error: any) => this.handleError(error.response));
    }
}

// export a singleton instance in the global namespace
export const poemService = PoemService.Instance;
