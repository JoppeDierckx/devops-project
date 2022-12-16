// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function aanwezig(){
    document.getElementById("aanwezig").innerHTML = "Uw aanwezigheid is bevestigd."
};
function afwezig(){
    document.getElementById("afwezig").innerHTML = "Uw afwezigheid is bevestigd."
};

const contentful = require('contentful-management');

async function Connect(){
    let client = await contentful.createClient({
        accessToken: 'CFPAT-ln72IpptaI4vlM1e9TUgH4TXitj194j_45cZeBj6aXk',
    });
    let space = await client.getSpace('b8nq3kc3lwwc');
    return await space.getEnvironment('master');
}

async function Updatetraining(env, trainingID1) {
    let training1 = await env.getEntry(trainingID1)
    console.log(training1);
    training1.fields.training['en-US'] = '2022-11-30T17:30+01:00';
    await training1.update();
    training1 = await env.getEntry(trainingID1);
    await training1.publish();
}

(async () => {
    let env = await Connect();
    await Updatetraining(env, '6zEroLxGKs4Fwu8CpU5mhD')
})();