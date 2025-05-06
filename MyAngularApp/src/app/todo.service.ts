import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment'; // Import environment

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  baseUrl = environment.baseUrl; // Use environment variable
  constructor(private http: HttpClient) { }

  getTodos(): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'TodoItems');
  }

  addTodo(todo: any): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'TodoItems', todo);
  }
}
