//https://json-generator.com/

[
    '{{repeat(12)}}',
    {
      
      name: '{{firstName()}}',
      contact: '{{street()}} {{city()}}',
      UserName: '{{firstName()}}',
      Email: '{{email([random])}}',
      PhoneNumber: '{{integer([900000000], [999999999] )}}',
      image:function(num){
      return 'https://randomuser.me/portraits/men/'+num.integer(1,99)+'.jpg';
      },
      observations:'{{lorem(1, "sentences")}}'    
    }
  ]
  
  