

// authenticate
//RhinoCompute.authToken = RhinoCompute.getAuthToken()

// if you have a different Rhino.Compute server, add the URL here:
RhinoCompute.url = 'http://localhost:8081/'
// if the above is not localhost, enter the api key here:
//RhinoCompute.apiKey = ''

compute()

/**
 * Call compute
 */
async function compute() {

    const filename = 'E:\\data\\Rhino_Logo.3dm'

    RhinoCompute.computeFetch('ms/convert3dmtofbx', [filename]).then( result => {
        console.log(result);
    })

}

