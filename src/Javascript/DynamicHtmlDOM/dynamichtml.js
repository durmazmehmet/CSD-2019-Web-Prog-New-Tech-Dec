let count = 1

function addPhoneText()
{
    let div = document.createElement("div")
    let input = document.createElement("input")

    input.type = "text"
    input.name=`phone${++count}`
    input.placeholder = "Input your other number"
    input.required = true
    div.appendChild(input)
    let register = document.getElementById("register")

    document.getElementsByTagName("body")[0].insertBefore(div, register)
}

function editPhones()
{
    let inputs = document.getElementsByTagName("input")

    document.getElementsByName("phones")[0].value = ""
    
    for (let input of inputs) {
        if (!input.name.startsWith("phone"))
            continue
        
        if (document.getElementsByName("phones")[0].value)
            document.getElementsByName("phones")[0].value += ","

            document.getElementsByName("phones")[0].value += input.value
    }
    
}
