import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../enviroments/environment'; // Asegúrate de tener configurado tu entorno

@Injectable({
  providedIn: 'root'
})
export class ServiciosContablesService {
  private apiUrl = `${environment.apiUrl}/api/contabilidad/registros`; // URL de tu endpoint

  constructor(private http: HttpClient) {}

  getRegistrosContables(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);  // Hacemos la petición GET al backend
  }
}
