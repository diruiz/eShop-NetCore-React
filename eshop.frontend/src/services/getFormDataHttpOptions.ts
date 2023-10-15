
export default function getFormDataHttpOptions(formData: FormData){
    let storage = localStorage.getItem("okta-token-storage");
    if(!storage)
    {
      storage = JSON.stringify({accessToken:{accessToken:''}}); 
    }
    const token = JSON.parse(storage)?.accessToken?.accessToken;
    var myHeaders = new Headers();
    myHeaders.append("accept", "text/plain");  
    myHeaders.append('Authorization', `Bearer ${token}`);
    var requestOptions = {
    method:'POST',
    headers: myHeaders,
    body: formData
  };
  return requestOptions;
}