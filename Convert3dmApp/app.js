

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

    

    // source a .3dm file in the same directory
    const filename = 'Rhino_Logo.3dm'
    const res = await fetch(filename)
    const buffer = await res.arrayBuffer()
    const buffer3dm = new Uint8Array(buffer)
    const bufferString = btoa(buffer3dm)

    RhinoCompute.computeFetch('ms/convert3dmtofbx', [bufferString]).then( result => {
        console.log(result);
    })

}

