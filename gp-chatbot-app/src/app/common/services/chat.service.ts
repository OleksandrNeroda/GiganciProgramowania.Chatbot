import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import {Message} from '../../components/message/message.interface';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  private apiUrl = 'https://localhost:7173/Chat';

  constructor(private http: HttpClient) {}

  sendMessage(userMessage: string): Observable<Message> {
    const payload = { message: userMessage };
    return this.http.post<Message>(`${this.apiUrl}/Send`, payload);
  }

  getAllMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(`${this.apiUrl}/GetAll`);
  }

  rateMessage(messageId: string, messageRateCode: string): Observable<any> {
    const payload = { messageRateCode: messageRateCode };
    return this.http.put<any>(`${this.apiUrl}/Rate/${messageId}`, payload);
  }
}
