# CSharp_AsyncWebScrape
## Reads web async in a Task
###### Previev
**Requires**
 ```cs
 System.Threading.Tasks
 System.IO
 System.Net
 ```
__Code Preview__
```cs 
var scrape= Task.Run( async () =>{
WebRequest request = HttpWebRequest.Create(new Uri("URL"));
WebResponse response = await request.GetResponseAsync();
StreamReader reader=new StreamReader(response.GetResponseStream());
return await reader.ReadToEndAsync();
}); 
// scrape.Result;
/*
Page's html storaging in scrape.Result;
Can require ".ToString()" 
*/
```


