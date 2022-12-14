import GetTutor from "./scenarios/GetTutor.js";
import {group , sleep} from 'k6';
import PostPet from "./scenarios/PostPet.js";

// export let options = {
//     stages: [
//         {target: 5, duration: "5s"},
//         {target: 20, duration: "15s"},
//         {target: 0, duration: "10s"}
//     ],
//     thresholds: {
//         "http_req_duration": ["p(95)<100"]
//     },
// };

export default () => {
    group('Endpoint Get Tutor - Controller Tutor - PetDoor.Api', () => {
        GetTutor();
    });
    group('Endpoint Post Pet - Controller Pet - PetDoor.Api', () => {
        PostPet();
    })

    sleep(1);
}