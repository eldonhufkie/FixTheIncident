//call geocode
geocode();
//GeoCode AXIOS JS
function geocode() {
    var location = 'summerstrand port elizabeth';
    axios.get('https://maps.googleapis.com/maps/api/geocode/json?', {
        params: {
            address: location,
            key: 'AIzaSyC60AAX4lAy9-hmzC53qaJpOGtY8Y1rhJo'
        }
    })
    .then(function (response) {
        console.log(response);
        // formatted Data
        var formattedAddress = response.data.results[0].formatted_address;
        var formattedAddressOutput = `
                    <ul class ="list-group">
                        <li class="list-group-item">${formattedAddress}</li>
                    </ul>
                    `;
        // Address Components
        var addressComponents = response.data.results[0].address_components;
        var addressComponentsOutput = '<ul class="list-group">'
        for (var i = 0; i < addressComponents.length; i++) {
            addressComponentsOutput += `
                                <li class ="list-group-item"><strong>${addressComponents[i].types[0]
            }</strong>:${addressComponents[i].long_name}</li>
                            `;
        }
        addressComponentsOutput += '</ul>';


        // Geometry
        var latitude = response.data.results[0].geometry.location.lat;
        var longitude = response.data.results[0].geometry.location.lng;

        var geometryOutput = `
                    <ul class ="list-group">
                        <li class ="list-group-item"><strong>Latitude</strong>:${latitude}</li>
                        <li class ="list-group-item"><strong>Longitude</strong>:${longitude}</li>
                    </ul>
                    `;

        //Output to app
        document.getElementById('formatted_address').innerHTML = formattedAddressOutput;
        document.getElementById('address-component').innerHTML = addressComponentsOutput;
        document.getElementById('geometry').innerHTML = geometryOutput;

        //Google Maps


    })
    .catch(function (error) {
        //error
        console.log(error);
    });
}