import http from 'k6/http';
import { sleep } from 'k6';
import { Trend, Rate, Counter } from "k6/metrics";
import { check, fail } from "k6";

export let GetTutorDuration = new Trend('get_Tutor_duration');
export let GetTutorFailRate = new Rate('get_Tutor_fail_rate');
export let GetTutorSuccessRate = new Rate('get_Tutor_success_rate');
export let GetTutorReqs = new Rate('get_Tutor_reqs');




export default function () {
    let res = http.get('https://localhost:5001/api/tutor/1')
    
    GetTutorDuration.add(res.timings.duration);
    GetTutorReqs.add(1);
    GetTutorFailRate.add(res.status == 0 || res.status > 399);
    GetTutorSuccessRate.add(res.status < 399);

    let durationMsg = 'Max Duration ${1000/1000}s'
    if(!check(res, {
        'max duration': (r) => r.timings.duration < 1000,
    })){
        fail(durationMsg);
    }
    
    sleep(1);

}