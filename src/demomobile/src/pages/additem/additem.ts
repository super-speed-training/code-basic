import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

/**
 * Generated class for the AdditemPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-additem',
  templateUrl: 'additem.html',
})
export class AdditemPage {

  public model: any;
  constructor(public navCtrl: NavController, public navParams: NavParams, private http:HttpClient) {
  }

  save(){
    let body = {
      "name": this.model,
      "isComplete": false
    };
    this.http.post("https://localhost:5001/api/todo",body).subscribe(
      (success)=>{
        this.navCtrl.popToRoot();
      }
    );
  }
}
