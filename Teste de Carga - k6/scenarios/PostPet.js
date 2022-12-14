import http from 'k6/http';
import { sleep } from 'k6';
import { Trend, Rate, Counter } from "k6/metrics";
import { check, fail } from "k6";

export let PostPetDuration = new Trend('post_Pet_duration');
export let PostPetFailRate = new Rate('post_Pet_fail_rate');
export let PostPetSuccessRate = new Rate('post_Pet_success_rate');
export let PostPetReqs = new Rate('post_Pet_reqs');




export default function () {
    const url = 'https://localhost:5001/api/Pets'
    const payload = JSON.stringify({
        Nome:"Nan",
        Genero:"F",
        Nascimento:"2000-07-09",
        Castrado:1,
        Animal:"Cat",
        Raca:"PCB",
        TutorId:3
    })
    const params = {
        headers: {
          'Content-Type': 'application/json',
        },
      };
    let res = http.post(url, payload, params)
    
    PostPetDuration.add(res.timings.duration);
    PostPetReqs.add(1);
    PostPetFailRate.add(res.status == 0 || res.status > 399);
    PostPetSuccessRate.add(res.status < 399);

    let durationMsg = 'Max Duration ${1000/1000}s'
    if(!check(res, {
        'max duration': (r) => r.timings.duration < 1000,
    })){
        fail(durationMsg);
    }
    
    sleep(1);

}