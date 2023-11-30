import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
private UserName$ = new BehaviorSubject<string>("");
private role$ = new BehaviorSubject<string>("");

constructor() { }

  public getRoleFromStore(){
    return this.role$.asObservable();
  }

  public setRoleForStore(role:string){
    this.role$.next(role);
  }

  public getFullNameFromStore(){
    return this.UserName$.asObservable();
  }

  public setFullNameForStore(UserName:string){
    this.UserName$.next(UserName)
  }
}