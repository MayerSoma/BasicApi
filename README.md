# Basic Web .Net Core Web Api

This application will simulate a self-checkout machine in a supermarket, which can be restocked,
and calculates which bills and coins should it give back as change when used.

It has 3 endpoints

# POST /api/v1/Stock

eg.: {"currency":"500", "volume":4}

The Stock endpoint  accept a JSON in a POST request, with an object containing the bills and coins to be
loaded into the “machine” (HUF).
• The keys should be the numerical values of the bills or coins, the value should be the number of the items
inserted. See example object below.
• The app should store the currently available currency in memory.
• The endpoint should return a 200 OK response, with the currently stored items in the response body, or an
appropriate error response if an exception occurs.

# GET /api/v1/Stock

The endpoint should return a 200 OK response, with the currently stored items in the response body, or an
appropriate error response if an exception occurs.

# POST /api/v1/Checkout
eg.: {"currency":"500", "volume":4}

The endpoint should accept the same object used in the POST request for the Stock endpoint, but this time the
object represents the bills and coins inserted into the machine by the customer during purchase. The JSON
should also contain a price field representing the total price of the purchase.
• The purchase, if successful, should update the number of bills and coins stored in the machine accordingly
• The endpoint should return with a
o 200 OK response, and an object containing the change given back by the machine
o 400 Bad Request response, with a response body describing the error if the purchase cannot be
fulfilled for some reason.
