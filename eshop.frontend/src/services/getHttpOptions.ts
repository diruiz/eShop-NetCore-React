
export default function getHttpOptions(method = 'GET', body: any|null = null ){
    let storage = localStorage.getItem("okta-token-storage");
    if(!storage)
    {
      storage = JSON.stringify({accessToken:{accessToken:''}}); 
    }
    const token = JSON.parse(storage)?.accessToken?.accessToken;
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    myHeaders.append('Authorization', `Bearer ${token}`);
    var requestOptions = {
    method,
    headers: myHeaders,
    body: body ? JSON.stringify(body) : null
  };
  return requestOptions;
}