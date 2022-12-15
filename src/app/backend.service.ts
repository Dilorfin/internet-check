import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ConnectionModel
{
	title: string;
	lastRequestTime: string;
	isOnline: boolean;
}

@Injectable({
	providedIn: 'root'
})
export class BackendService
{
	constructor(private http: HttpClient) { }

	public getAllConnections(): Observable<ConnectionModel[]>
	{
		return this.http.get<ConnectionModel[]>("/api/GetAll");
	}
}
